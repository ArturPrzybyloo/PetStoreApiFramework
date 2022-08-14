using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiFramework.Dto
{
    public class PetDto
    {
        // Id of pet
        public Int64? Id { get; set; }
        // Object containing pet category informations
        public PetCategoryDto Category { get; set; }
        // Pet name
        public string Name { get; set; }
        // List of photo urls
        public IList<string> PhotoUrls {get; set;}
        // List of tag objects
        public IList<TagDto> Tags { get; set; }
        // Status of pet
        public string Status { get; set; }
    }

}
