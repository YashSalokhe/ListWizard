using Microsoft.AspNetCore.Hosting;
using System.Data;

namespace ListWizard.Services
{
    public class FileService
    {
        //private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor http;
        IWebHostEnvironment hostEnvironment;
        private readonly ListWizardContext context;


        public FileService(IHttpContextAccessor http, IWebHostEnvironment hostEnvironment, ListWizardContext context)
        {
            this.hostEnvironment = hostEnvironment;
            this.http = http;
            this.context = context;
        }

        public async Task<Upload> FileUploadAsync(Upload upload)
        {
            var createdList = http.HttpContext.Session.GetObject<WizardList>("newListInfo");
            IFormFile uploadedFile = upload.File;
            var postedFileName = ContentDispositionHeaderValue
                    .Parse(uploadedFile.ContentDisposition)
                    .FileName.Trim('"');

            FileInfo fileInfo = new FileInfo(postedFileName);

            if (fileInfo.Extension == ".csv")
            {
                List<CsvContent> content = new List<CsvContent>();
                int missingFields = 0;
                int presentFields = 0;
                var finalPath = Path.Combine(hostEnvironment.WebRootPath, "Files", postedFileName);

                using (var fs = new FileStream(finalPath, FileMode.Create))
                {
                    

                    // Create a File into the folder
                    uploadedFile.CopyTo(fs);


                    var temp = await context.WizardLists.AddAsync(createdList);
                    var hold = await context.SaveChangesAsync(); 
                }


                //Read the contents of CSV file.
                string csvData = File.ReadAllText(finalPath);
                
                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (row.Split(',')[0] != string.Empty && row.Split(',')[1] != string.Empty && row.Split(',')[2] != string.Empty && row.Split(',')[3] != string.Empty && row.Split(',')[4] != string.Empty)
                        {
                            presentFields++;

                            content.Add(new CsvContent
                            {
                                FirstName = row.Split(',')[0],
                                LastName = row.Split(',')[1],
                                CompanyName = row.Split(',')[2],
                                Title = row.Split(',')[3],
                                Email = row.Split(',')[4],
                                ListId = createdList.ListId
                            });
                        }
                        else
                        {
                            missingFields++;
                        }
                    }                   
                }
                await context.CsvContents.AddRangeAsync(content);
                await context.SaveChangesAsync();

                Upload newUpload = new Upload()
                {
                    File = upload.File,
                    csvContents = content,
                    MissingField = missingFields,
                    ImportedField = presentFields
                };
                return newUpload;
            }

            return null;
        }
    }
}
