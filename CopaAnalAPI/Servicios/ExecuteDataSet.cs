using System.Data;
using System.Data.SqlClient;

namespace CopaAnalAPI.Servicios
{
    public class ExecuteDataSet
    {
        private string _cnnString;
        public ExecuteDataSet(string cnnString) { 
            this._cnnString = cnnString;
        } 
        public async Task<DataSet> ExecuteStoredProcedure(string storedProcedureName,Dictionary<string,string> prams= null)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(this._cnnString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (prams != null)
                        {
                            foreach (var item in prams)
                            {
                                command.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            await Task.Run(() =>
                                {
                                    adapter.Fill(dataSet);
                                });
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return dataSet;
        }
    }
}
