using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ImageSelected { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MemeText { get; set; } = "";
        public string SelectedImageUrl { get; set; }
        public List<MemeImage> MemeImages { get; set; }
        public string ErrorMessage { get; set; } = "";
        public List<SelectListItem> Positions { get; set; }
        public List<SelectListItem> Colors { get; set; }
        public List<SelectListItem> Sizes { get; set; }


        public void OnGet()
        {
            Initialize();
            MemeImageRepository repo = new MemeImageRepository();
            MemeImages = repo.GetAllMemeImages();

            if (ImageSelected > 0)
            {
                //Show the meme on the page
                SelectedImageUrl = repo.GetMemeImageUrl(ImageSelected);

                //Save the meme in DB
                SaveMemeInDb();
            }
        }

        private void Initialize()
        {
            Positions = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Bunden til venstre", Value = "bottom-left" },
                new SelectListItem() { Text = "Bunden til højre", Value = "bottom-right" },
                new SelectListItem() { Text = "Toppen i midten", Value = "top-center" }
            };

            Colors = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Hvid", Value = "white" },
                new SelectListItem() { Text = "Sort", Value = "black" },
                new SelectListItem() { Text = "Grøn", Value = "green" },
                new SelectListItem() { Text = "Rød", Value = "red" }
            };

            Sizes = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Lille", Value = "small" },
                new SelectListItem() { Text = "Mellem", Value = "medium" },
                new SelectListItem() { Text = "Stor", Value = "large" }
            };
        }

        private void SaveMemeInDb()
        {
            MemeCreationRepository memeCreateionRepo = new MemeCreationRepository();

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