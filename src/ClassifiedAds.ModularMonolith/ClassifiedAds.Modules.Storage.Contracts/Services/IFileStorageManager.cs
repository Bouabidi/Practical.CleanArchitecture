﻿using ClassifiedAds.Modules.Storage.Contracts.DTOs;
using System.IO;

namespace ClassifiedAds.Modules.Storage.Contracts
{
    public interface IFileStorageManager
    {
        void Create(FileEntryDTO fileEntry, MemoryStream stream);
        byte[] Read(FileEntryDTO fileEntry);
        void Delete(FileEntryDTO fileEntry);
    }
}
