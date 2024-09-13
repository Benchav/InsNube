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
    }

}