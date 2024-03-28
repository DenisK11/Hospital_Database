using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;

namespace Hospital_DataBase_API.Data
{
    public static class SectionStore
    {
        public static List<Section> sectionList = new List<Section> {
             new Section {Id=1,Name="Pediatrie"},
             new Section {Id=2,Name="ORL"}
             };
    }
}
