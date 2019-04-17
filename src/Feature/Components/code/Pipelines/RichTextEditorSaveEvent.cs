using System;
using EMAAR.ECM.Feature.ContentComponents.Settings;
using HtmlAgilityPack;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;
namespace EMAAR.ECM.Feature.ContentComponents.Pipelines
{
    public class RichTextEditorSaveEvent
    {
        public string Database
        {
            get;
            set;
        }

        public void OnItemSaving(object sender, EventArgs args)
        {

            Item item = Event.ExtractParameter(args, 0) as Item;
            if (item == null)
            {
                return;
            }
            if (item.TemplateID == ID.Parse(SitecoreSettings.GenericTemplateID))
            {
                return;
            }
            if ((item.Database != null && string.Compare(item.Database.Name, Database) != 0))
            {
                return;
            }
            try
            {
                foreach (Field field in item.Fields)
                {
                    if (!field.TypeKey.Equals("rich text", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    string content = field.Value;

                    if (!string.IsNullOrEmpty(content))
                    {
                        content = content.Trim();

                        try
                        {
                            HtmlDocument htmlDocument = new HtmlDocument();
                            htmlDocument.LoadHtml(content);
                            RemoveEmptyDivTags(htmlDocument);
                            FormatProperHTML(htmlDocument);
                            RemoveEmptyPTags(htmlDocument);
                            content = htmlDocument.DocumentNode.InnerHtml;

                        }
                        catch (Exception ex)
                        {
                            Sitecore.Diagnostics.Log.Error("Error occured in RTE Saving :RichTextEditorSaveEvent.cs :Error  " + ex, this);
                        }

                        using (new SecurityDisabler())
                        {
                            item.Editing.BeginEdit();
                            field.Value = content;
                            item.Editing.EndEdit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Error occured in RTE Saving :RichTextEditorSaveEvent.cs : Error " + ex, this);
            }

        }

        private void FormatProperHTML(HtmlDocument content)
        {
            HtmlNodeCollection imgNodes = content.DocumentNode.SelectNodes("//text()");
            if (imgNodes != null && imgNodes.Count > 0)
            {
                foreach (HtmlNode divTag in imgNodes)
                {
                    if (divTag.ParentNode != null && divTag.ParentNode.Name == "div")
                    {
                        HtmlNode title = HtmlNode.CreateNode("<p>" + divTag.InnerHtml.Replace("<br />", "<p/><p>") + "</p>");
                        divTag.InnerHtml = title.OuterHtml;
                    }
                }

            }
            HtmlNodeCollection nodes = content.DocumentNode.SelectNodes("//p");
            if (nodes == null)
            {
                return;
            }

            foreach (HtmlNode node in nodes)
            {
                node.InnerHtml = node.InnerHtml.Trim();
                if (node.InnerHtml.StartsWith("<!"))
                {
                    HtmlNode title = HtmlNode.CreateNode(node.InnerHtml);
                    node.ParentNode.ReplaceChild(title, node);

                }
                node.Attributes.Remove("class");
            }
            HtmlNodeCollection brnodes = content.DocumentNode.SelectNodes("//br");
            if (brnodes == null)
            {
                return;
            }

            foreach (HtmlNode node in brnodes)
            {
                node.ParentNode.RemoveChild(node);
            }
        }

        private void RemoveEmptyPTags(HtmlDocument content)
        {
            HtmlNodeCollection pNodes = content.DocumentNode.SelectNodes("//p");
            if (pNodes != null && pNodes.Count > 0)
            {
                foreach (HtmlNode pTag in pNodes)
                {
                    if (string.IsNullOrWhiteSpace(pTag.InnerHtml) || pTag.InnerHtml == "&nbsp;" || pTag.InnerHtml == "\n" || pTag.InnerHtml == "\n\n")
                    {
                        pTag.ParentNode.RemoveChild(pTag);
                    }
                }
            }
        }
        private void RemoveEmptyDivTags(HtmlDocument content)
        {
            HtmlNodeCollection pNodes = content.DocumentNode.SelectNodes("//div");
            if (pNodes != null && pNodes.Count > 0)
            {
                foreach (HtmlNode divTag in pNodes)
                {
                    if (string.IsNullOrWhiteSpace(divTag.InnerHtml) || divTag.InnerHtml == "&nbsp;" || divTag.InnerHtml == "\n" || divTag.InnerHtml == "\n\n")
                    {
                        divTag.ParentNode.RemoveChild(divTag);
                    }
                }
            }
        }
    }
}


