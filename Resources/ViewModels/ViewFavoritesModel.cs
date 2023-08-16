using MAUIpractice.Resources.Models;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIpractice.Resources.ViewModels
{
    public class ViewFavoritesModel
    {
        public ObservableCollection<FavoritesModel> Favorites { get; set; }
        public string Path { get; set; }
        public Command<FavoritesModel> Delete { get; private set; }

        public ViewFavoritesModel() 
        {
            Favorites = new ObservableCollection<FavoritesModel>();

            Delete = new Command<FavoritesModel>(data => 
            {
                Favorites.Remove(data);
            });

            PopulateFavorites();
        }

        public string AddFavorite(string location)
        {
            string response = "Location already in list.";

            if (location.Length < 4)
            {
                response = "Must be 4 characters long.";
                return response;
            }
            else if(location.Length > 4) 
            {
                response = "Must not exceed 4 characters.";
                return response;
            }

            foreach(var favorite in Favorites)
            {
                if (favorite.Location == location)
                {
                    return response;
                }
            }

            Favorites.Add(new FavoritesModel() { Location = location });
            response = location + " added to the list.";
            return response;
        }

        public void PopulateFavorites()
        {
            //Path = Directory.GetCurrentDirectory();
            Path = "C:\\Users\\Fabio Weck\\Documents\\My projects\\MAUIpractice\\Resources\\Files\\favorites.csv";

            using (StreamReader streamReader = new StreamReader(Path))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {

                    Favorites.Add(new FavoritesModel() { Location = line });

                }

                streamReader.Close();
            }
        }
    }
}
