using System.Dynamic;
using System.Text.Json;

namespace LibraryMVC.Models
{
        public abstract class JsonRepository<Datatype> {

        protected String default_path = "";

        protected JsonRepository() {
            this.filePath = default_path;
        }

        protected JsonRepository(String newFilePath) {
            this.filePath = newFilePath;
        }

        public String filePath { get; }

        public void writeData(List<Datatype> data)
        {
			string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions() { WriteIndented = true });
			using (StreamWriter outputFile = new StreamWriter(this.filePath))
			{
				outputFile.WriteLine(jsonString);
			}
		}

        public List<Datatype> readData()
        {
			List<Datatype>? data = new List<Datatype>();
			using (StreamReader r = new StreamReader(this.filePath))
			{
				string json = r.ReadToEnd();
				data = JsonSerializer.Deserialize<List<Datatype>>(json);
			}

            if(data == null)
            {
                return new List<Datatype>();
            }
            
            return data;
		}

        protected void updateData(Datatype updatedData, Predicate<Datatype> findBy)
        {
            List<Datatype> data = readData();
            int foundIndex = data.FindIndex(findBy);
            data[foundIndex] = updatedData;
            writeData(data);
        }


        protected Datatype? find(Predicate<Datatype> findBy)
        {
            List<Datatype> data = readData();
            Datatype? foundData = data.Find(findBy);
            return foundData;
        }

        public abstract Boolean exists(Datatype target);

        public void delete(Datatype target) {
            List<Datatype> data = readData();
            data.Remove(target);
            writeData(data);
        }


    }
}
