using PayloadPost.ViewRenders.Interfaces;
using System;
using System.Text;

namespace PayloadPost.ViewRenders
{
    public class PlainTextContentRenderer : IPlainTextContentRenderer
    {
        public string RenderModelToString(object model)
        {
            StringBuilder messageBuilder = new StringBuilder();

            var props = model.GetType().GetProperties();
            foreach (var propinfo in props)
            {
                messageBuilder.AppendLine($@"{propinfo.Name}: {propinfo.GetValue(model)}.");
            }         

            return messageBuilder.ToString();
        }
    }
}
