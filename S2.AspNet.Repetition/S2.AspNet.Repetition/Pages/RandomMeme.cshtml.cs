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
    public class RandomMemeModel : PageModel
    {
        public MemeCreation Meme { get; set; }
        public void OnGet()
        {
            MemeCreationRepository repo = new MemeCreationRepository();

            Meme = repo.GetRandomMeme();

        }
    }
}