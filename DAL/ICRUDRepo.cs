using System.Collections.Generic;

namespace DAL
{
	public interface ICRUDRepo<ModelT>
	{
		// CREATE
		void CreateRow(ModelT modelObj);
		
		// READ
		IEnumerable<ModelT> GetAllRows();

		ModelT GetRowById(int id);
		ModelT GetRowByKey(string key);
		
		// UPDATE
		void UpdateRow(ModelT modelObj);
		
		// DELETE
		void DeleteRow(ModelT modelObj);

		bool SaveChanges();
	}
}
