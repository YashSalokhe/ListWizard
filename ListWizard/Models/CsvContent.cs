using System;
using System.Collections.Generic;

namespace ListWizard.Models
{
    public partial class CsvContent
    {
        public int CsvId { get; set; }
        public int ListId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }

        public virtual WizardList List { get; set; } = null!;
    }
}
