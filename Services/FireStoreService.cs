using FirebaseExamenple2.Models.Entities;
using Google.Cloud.Firestore;

namespace FirebaseExamenple2.Services
{
    public class FirebaseService{
        private readonly FirestoreDb _firestoreDB;
        private const string CollectionName = "CatProducto";
          private const string CollectionNam = "Categorie";
        public FirebaseService (){
            _firestoreDB = FirestoreDb.Create("crud-app-a6f41");
        }

        public async Task<ProductoEntities> createProduct(ProductoEntities producto){
        try{
             DocumentReference doc = _firestoreDB.Collection(CollectionName).Document();
             producto.Id = doc.Id;
             await doc.SetAsync(producto);
             return producto;
            }

            catch (Exception ex)
            {
              Console.WriteLine($"Eror al crear el producto en Firestore: {ex.Message}");
              throw new Exception("Eror al crear el producto en firestore.", ex);
            }
        }



         public async Task<CategorieEntities> createCategorie(CategorieEntities categorie){
        try{
             DocumentReference doc = _firestoreDB.Collection(CollectionNam).Document();
             categorie.Id = doc.Id;
             await doc.SetAsync(categorie);
             return categorie;
            }

            catch (Exception ex)
            {
              Console.WriteLine($"Eror al crear la categoria en Firestore: {ex.Message}");
              throw new Exception("Eror al crear la categoria en firestore.", ex);
            }
        }

 // Método para actualizar una categoría por ID
        public async Task<CategorieEntities> UpdateCategorie(string id, CategorieEntities updatedCategorie){
            try{
                DocumentReference docRef = _firestoreDB.Collection(CollectionNam).Document(id);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists){
                    throw new Exception($"La categoría con ID {id} no existe.");
                }

                await docRef.SetAsync(updatedCategorie, SetOptions.Overwrite);
                return updatedCategorie;
            }
            catch (Exception ex){
                Console.WriteLine($"Error al actualizar la categoría en Firestore: {ex.Message}");
                throw new Exception("Error al actualizar la categoría en Firestore.", ex);
            }
        }

        // Método para eliminar una categoría por ID
        public async Task DeleteCategorie(string id){
            try{
                DocumentReference docRef = _firestoreDB.Collection(CollectionName).Document(id);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists){
                    throw new Exception($"La categoría con ID {id} no existe.");
                }

                await docRef.DeleteAsync();
            }
            catch (Exception ex){
                Console.WriteLine($"Error al eliminar la categoría en Firestore: {ex.Message}");
                throw new Exception("Error al eliminar la categoría en Firestore.", ex);
            }
        }

        // Método para ver todas las categorías
        public async Task<List<CategorieEntities>> VerCategories(){
            try{
                CollectionReference categoriesRef = _firestoreDB.Collection(CollectionName);
                QuerySnapshot snapshot = await categoriesRef.GetSnapshotAsync();

                List<CategorieEntities> categoriesList = new List<CategorieEntities>();

                foreach (DocumentSnapshot document in snapshot.Documents){
                    if (document.Exists){
                        CategorieEntities categorie = document.ConvertTo<CategorieEntities>();
                        categorie.Id = document.Id;
                        categoriesList.Add(categorie);
                    }
                }

                return categoriesList;
            }
            catch (Exception ex){
                Console.WriteLine($"Error al obtener las categorías en Firestore: {ex.Message}");
                throw new Exception("Error al obtener las categorías en Firestore.", ex);
            }
        }


    }
}