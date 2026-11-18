using DevExpress.Drawing;
namespace IcuInteropExample.Client
{
    public static class FontLoader
    {
        public static async Task LoadFonts(HttpClient httpClient, List<string> fontNames)
        {
            foreach (var fontName in fontNames)
            {
                var fontBytes = await httpClient.GetByteArrayAsync($"fonts/{fontName}");
                DXFontRepository.Instance.AddFont(fontBytes);
            }
        }
    }
}
