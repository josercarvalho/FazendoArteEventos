﻿using System.ComponentModel.DataAnnotations;

namespace Evento.UI.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
