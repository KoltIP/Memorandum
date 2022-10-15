using Memorandum.Db.Context.Context;
using Memorandum.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorandum.Db.Context.Setup
{
    public static class DbSeed
    {
        public static void AddData(MemorandumDbContext context)
        {
            if (context.Notes.Any() || context.Categories.Any())
                return;

            var category1 = new Category()
            {
                Id = 1,
                Name = "Категория 1",
                Description = "Описание категории 1",
            };
            context.Categories.Add(category1);


            var category2 = new Category()
            {
                Id = 2,
                Name = "Категория 2",
                Description = "Описание категории 2",
            };
            context.Categories.Add(category2);

            var category3 = new Category()
            {
                Id = 3,
                Name = "Категория 3",
                Description = "Описание категории 3",
            };
            context.Categories.Add(category3);



            var note1 = new Note()
            {
                Id = 1,
                Name = "Заметка 1",
                Description = "Описание заметики 1",
                CategoryId = 1,
            };
            context.Notes.Add(note1);

            var note2 = new Note()
            {
                Id = 2,
                Name = "Заметка 2",
                Description = "Описание заметики 2",
                CategoryId = 2,
            };
            context.Notes.Add(note2);

            var note3 = new Note()
            {
                Id = 3,
                Name = "Заметка 3",
                Description = "Описание заметики 3",
                CategoryId = 3,
            };
            context.Notes.Add(note3);

            context.SaveChanges();
        }
    }
}
