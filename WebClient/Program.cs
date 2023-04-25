using System.Text;

namespace WebApiClient;

class program
    {
         static async Task Main(string[] args)
         {
           HttpClient client = new HttpClient();
           Console.WriteLine("Enter ur choice");
           Console.WriteLine("1.Create");
           Console.WriteLine("2.Update");
           Console.WriteLine("3.Get");
           Console.WriteLine("4.GetById");
           Console.WriteLine("5.DeleteById");
           int choice = Convert.ToInt32(Console.ReadLine());
           switch(choice)
        {
            case 1:
                Console.WriteLine("Enter the employee details:");
                Console.WriteLine("Enter Name:");
                String name=Console.ReadLine();
                
                Console.WriteLine("Enter Phonenumber");
                long phonenumber=Convert.ToInt64(Console.ReadLine());
                
                Console.WriteLine("Enter Email");
                String email = Console.ReadLine();
                
                Console.WriteLine("Enter Pincode");
                int pincode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter City");
                String city = Console.ReadLine();

                Console.WriteLine("Enter Salary");
                int salary = Convert.ToInt32(Console.ReadLine());

                var result = new { Name = name, PhoneNumber = phonenumber, Email = email, Pincode = pincode,City=city, Salary = salary };
                var  json=Newtonsoft.Json.JsonConvert.SerializeObject(result);  
                var content=new StringContent(json,Encoding.UTF8,"application/json");
                HttpResponseMessage Response = await client.PostAsync("https://localhost:7262/api/Employee", content);
                if (Response.IsSuccessStatusCode)
                {
                    string output = await Response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Data added successfully. Result: {output}");
                }
                else
                {
                    Console.WriteLine($"Failed to add data: {Response.StatusCode}");
                }
                Console.ReadKey();
                break;

                case 2:
                Console.WriteLine("Enter Id:");
                int id= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber:");
                phonenumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email:");
                email = Console.ReadLine();
                Console.WriteLine("Enter City");
                city = Console.ReadLine();
                Console.WriteLine("Enter Pincode:");
                pincode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Salary:");
                salary = Convert.ToInt32(Console.ReadLine());
                var datas = new {Id=id,Name = name, PhoneNumber = phonenumber, Email = email,City=city, Pincode = pincode, Salary = salary };
                var Json = Newtonsoft.Json.JsonConvert.SerializeObject(datas);
                var contents = new StringContent(Json, Encoding.UTF8, "application/json");
                HttpResponseMessage Responses= await client.PutAsync("https://localhost:7262/api/Employee", contents);
                if (Responses.IsSuccessStatusCode)
                {
                    string output = await Responses.Content.ReadAsStringAsync();
                    Console.WriteLine($"Data updated successfully. Result: {output}");
                }
                else
                {
                    Console.WriteLine($"Failed to update data: {Responses.StatusCode}");
                }
                Console.ReadLine();
                break;



            case 3:
                
                HttpResponseMessage ResponseMsg = await client.GetAsync("https://localhost:7262/api/Employee");

                if (ResponseMsg.IsSuccessStatusCode)
                {

                    var res = await ResponseMsg.Content.ReadAsStringAsync();
                    Console.WriteLine(res);
                }
                else
                {
                    Console.WriteLine($"failed to fetch data:{ResponseMsg.StatusCode}");
                }

                Console.ReadLine();
                break;
            
            case 4:
                Console.WriteLine("Enter Id:");
                id=Convert.ToInt32(Console.ReadLine());
                
                HttpResponseMessage Respon = await client.GetAsync("https://localhost:7262/api/Employee/GetEmployeebyId?Id="+id);
                if (Respon.IsSuccessStatusCode)
                {
                    string output = await Respon.Content.ReadAsStringAsync();
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {Respon.StatusCode}");
                   
                }
                Console.ReadLine();
                break;

            case 5:
                Console.WriteLine("Enter Id:");
                id = Convert.ToInt32(Console.ReadLine());

                HttpResponseMessage value = await client.DeleteAsync("https://localhost:7262/api/Employee?id=" + id);
                if (value.IsSuccessStatusCode)
                {
                   
                    Console.WriteLine(value);
                }
                else
                {
                    Console.WriteLine($"Failed to delete data: {value.StatusCode}");

                }
                Console.ReadLine();
                break;
           
           default:

                Console.WriteLine("Invalid Choice");
                break;
        }



    }



       

    }
    

