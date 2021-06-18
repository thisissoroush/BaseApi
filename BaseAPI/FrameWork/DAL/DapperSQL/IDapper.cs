using FrameWork.DAL.DapperSQL;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FrameWork.DAL.DapperSQl
{
    public interface IDapper<T> where T : class
    {
        public Task Execute(string query, List<InputParameters> parameters = null, ExecutionType executionType = ExecutionType.query);
        public List<T> ExecuteReader(string query, List<InputParameters> parameters = null);
        public List<T> Query(string query, List<InputParameters> parameters = null);
    }
}
