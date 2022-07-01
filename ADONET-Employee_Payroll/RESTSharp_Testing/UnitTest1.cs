using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace RESTSharp_Testing
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    [TestClass]
    public class RESTSharp
    {
        RestClient client;

        [TestMethod]
        public void OnCallingGetMethod_CompareCount_ShouldReturnEmployeeList()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(12, list.Count);
            foreach (Employee value in list)
            {
                Console.WriteLine("Id:" + value.id + ",\t " + value.Name + ",\t " + value.Salary);
            }
        }
        [TestMethod]
        public void OnPostingEmployeeData_AddtoJsonServer_ReturnRecentlyAddedData()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Post);
            var body = new Employee { Name = "Reshu", Salary = "55000" };
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee value = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Reshu", value.Name);
            Assert.AreEqual("55000", value.Salary);
            Console.WriteLine(response.Content);
        }        
    }
}