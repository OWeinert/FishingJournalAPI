﻿using AutoMapper;
using FishingJournal.API.Models.JournalEntryModels;
using SixLabors.ImageSharp.Formats.Png;
using System.IO;

namespace FishingJournal.API.Helpers
{
    public class ImagePathResolver : IMemberValueResolver<JournalEntry, JournalEntryDTO, string, byte[]>
    {
        public byte[] Resolve(JournalEntry source, JournalEntryDTO destination, string sourceMember, byte[] destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(sourceMember))
            {
                var image = Image.Load(sourceMember);
                using var ms = new MemoryStream();
                image.Save(ms, new PngEncoder());
                return ms.ToArray();
            }
            return Array.Empty<byte>();
        }
    }
}
