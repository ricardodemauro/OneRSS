using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel;

namespace OneRSS.Data.Storage
{
    public class UserStorage
    {
        public static async Task<string> ReadTextFromFile(string fileName)
        {
            try
            {
                var stream = await OpenFileReadAsync(fileName, FilePathKind.DataFolder);
                if (stream == null)
                {
                    stream = await OpenFileReadAsync(fileName, FilePathKind.InstalledFolder);
                }
                using (var streamReader = new StreamReader(stream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.ReadTextFromFile", ex);
            }
            return String.Empty;
        }

        public static async Task WriteText(string fileName, string content)
        {
            try
            {
                var storageFile = await CreateFileAsync(fileName);
                await FileIO.WriteTextAsync(storageFile, content);
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.WriteText", ex);
            }
        }

        public static async Task DeleteFileIfExists(string fileName)
        {
            try
            {
                StorageFile file = await GetFileAsync(fileName, FilePathKind.DataFolder);
                if (file == null)
                {
                    file = await GetFileAsync(fileName, FilePathKind.InstalledFolder);
                }

                if (file != null)
                {
                    await file.DeleteAsync();
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                AppLogs.WriteError("UserStorage.DeleteFileIfExists", ex);
            }
        }

        public static async Task AppendLineToFile(string fileName, string line)
        {
            try
            {
                var storageFile = await CreateFileAsync(fileName);
                string oldContent = string.Empty;
                using (StreamReader streamReader = new StreamReader(await storageFile.OpenStreamForReadAsync()))
                {
                    oldContent = await streamReader.ReadToEndAsync();
                }
                await FileIO.WriteTextAsync(storageFile, oldContent + Environment.NewLine + line);
            }
            catch { /* Avoid any exception at this point. */ }
        }

        private async static Task<StorageFolder> GetFolderAsync(string directoryPath, FilePathKind filePathKind)
        {
            try
            {
                switch (filePathKind)
                {
                    case FilePathKind.InstalledFolder:
                        return await Package.Current.InstalledLocation.GetFolderAsync(directoryPath);
                    case FilePathKind.DataFolder:
                        return await ApplicationData.Current.LocalFolder.GetFolderAsync(directoryPath);
                    case FilePathKind.AbsolutePath:
                        return await StorageFolder.GetFolderFromPathAsync(directoryPath);
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        protected async static Task<Stream> OpenFileReadAsync(string filePath, FilePathKind filePathKind)
        {
            var file = await GetFileAsync(filePath, filePathKind);
            if (file == null)
            {
                return null;
            }
            var randomStream = await file.OpenReadAsync();
            return randomStream.AsStream();
        }

        private async static Task<StorageFile> GetFileAsync(string filePath, FilePathKind filePathKind)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileName(filePath);
            var storageFolder = await GetFolderAsync(directoryPath, filePathKind);
            if (storageFolder == null)
            {
                return null;
            }

            try
            {
                return await storageFolder.GetFileAsync(fileName);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static async Task<Windows.Storage.StorageFile> CreateFileAsync(string key,
            FilePathKind fileKind = FilePathKind.DataFolder,
            CreationCollisionOption option = CreationCollisionOption.OpenIfExists)
        {
            switch (fileKind)
            {
                case FilePathKind.DataFolder:
                    return await ApplicationData.Current.LocalFolder.CreateFileAsync(key, option);
                case FilePathKind.InstalledFolder:
                    return await Package.Current.InstalledLocation.CreateFileAsync(key, option);
                case FilePathKind.AbsolutePath:
                default:
                    throw new NotSupportedException(fileKind.ToString());
            }
        }


        public enum FilePathKind
        {
            InstalledFolder,
            DataFolder,
            AbsolutePath,
        }
    }
}
