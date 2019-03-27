using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class IndexModel : PageModel
    {
        private const string ConString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;";

        [BindProperty(SupportsGet = true)]
        public int ImageSelected { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MemeText { get; set; } = "";
        public string SelectedImageUrl { get; set; }
        public List<MemeImage> MemeImages { get; set; }
        public string ErrorMessage { get; set; } = "";
        public void OnGet()
        {
            MemeImageRepository repo = new MemeImageRepository(ConString);
            MemeImages = repo.GetAllMemeImages();

            if (ImageSelected > 0)
            {
                //Show the meme on the page
                SelectedImageUrl = repo.GetMemeImageUrl(ImageSelected);

                //Save the meme in DB
                SaveMemeInDb();

            }
        }

        private void SaveMemeInDb()
        {
            MemeCreationRepository memeCreateionRepo = new MemeCreationRepository(ConString);

            MemeCreation memeCreation = new MemeCreation()
            {
                MemeImageId = ImageSelected,
                Text = MemeText
            };

            int rowsAffected = memeCreateionRepo.Insert(memeCreation);

            if (rowsAffected != 1)
            {
                ErrorMessage = "Memet blev ikke oprettet i databasen :(";
                //Create an errormessage or log the problem somewhere
            }
        }
    }
}