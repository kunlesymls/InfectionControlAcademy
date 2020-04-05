namespace System
{
    public static class ByteExtension
    {
        public static string ImageContentType { get; set; } = "image/png";
        public static string ToCustomImage(this byte[] byteValue)
        {
            if (byteValue == null || ImageContentType == null)
            {
                return null;
            }
            var base64Image = Convert.ToBase64String(byteValue);
            return  $"data:{ImageContentType};base64,{base64Image}";
        }
    }
}
