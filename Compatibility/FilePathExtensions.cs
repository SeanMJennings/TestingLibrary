namespace Compatibility;

public static class FilePathExtensions
{
    public static string ConvertToLinuxCompatibleFilePath(this string filePath) => filePath.Replace("\\", "/");
}