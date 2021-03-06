

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using ProxyApi.Proxies.Models;

// Proxies
namespace ProxyApi.Proxies
{
    public partial class Configuration
	{
		public const string TestApiBaseAddress = "http://localhost:59717";
		
	}
}

namespace ProxyApi.Proxies.Models
{
	#region Models
	public partial class Person
	{
		public virtual Int32 Id { get; set; }
		public virtual String FirstName { get; set; }
		public virtual String LastName { get; set; }
		public virtual String PetName { get; set; }
	}
	#endregion
}


namespace ProxyApi.Proxies.Clients
{
	public partial class PeopleClient : IDisposable
	{

		public HttpClient HttpClient { get; private set; }

		/// <summary>
        /// Some docs come here
        /// </summary>
		public PeopleClient()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.TestApiBaseAddress)
			};
		}

		/// <summary>
        /// Some docs come here
        /// </summary>
		public PeopleClient(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.TestApiBaseAddress)
			};
		}

		#region Methods
        /// <summary>
        /// Gets all people in this API
        /// </summary>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync()
		{
			return await HttpClient.GetAsync("api/People");
		}

        /// <summary>
        /// Searches for people with a given name
        /// </summary>
		/// <param name="name">the search criteria</param>
		/// <param name="id"></param>
		/// <param name="other"></param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(String name,Int32 id,String other)
		{
			return await HttpClient.GetAsync("api/People/" + id + "?name=" + name + "&other=" + other);
		}

        /// <summary>
        /// 
        /// </summary>
		/// <param name="id"></param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(Int32 id)
		{
			return await HttpClient.GetAsync("api/People/" + id);
		}

        /// <summary>
        /// Creates a new person
        /// </summary>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostAsync(Person person)
		{
			return await HttpClient.PostAsJsonAsync<Person>("api/People", person);
		}

        /// <summary>
        /// Update a person
        /// </summary>
		/// <param name="id">id of the guy</param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> PutAsync(Int32 id,Person person)
		{
			return await HttpClient.PutAsJsonAsync<Person>("api/People/" + id, person);
		}

		#endregion

		public void Dispose()
        {
            HttpClient.Dispose();
        }
	}

}
namespace ProxyApi.Proxies.Clients
{
	public partial class ValuesClient : IDisposable
	{

		public HttpClient HttpClient { get; private set; }

		/// <summary>
        /// 
        /// </summary>
		public ValuesClient()
		{
			HttpClient = new HttpClient()
			{
				BaseAddress = new Uri(Configuration.TestApiBaseAddress)
			};
		}

		/// <summary>
        /// 
        /// </summary>
		public ValuesClient(HttpMessageHandler handler, bool disposeHandler = true)
		{
			HttpClient = new HttpClient(handler, disposeHandler)
			{
				BaseAddress = new Uri(Configuration.TestApiBaseAddress)
			};
		}

		#region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync()
		{
			return await HttpClient.GetAsync("api/Values");
		}

        /// <summary>
        /// 
        /// </summary>
		/// <param name="id"></param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> GetAsync(Int32 id)
		{
			return await HttpClient.GetAsync("api/Values/" + id);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> PostAsync(String value)
		{
			return await HttpClient.PostAsJsonAsync<String>("api/Values", value);
		}

        /// <summary>
        /// 
        /// </summary>
		/// <param name="id"></param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> PutAsync(Int32 id,String value)
		{
			return await HttpClient.PutAsJsonAsync<String>("api/Values/" + id, value);
		}

        /// <summary>
        /// 
        /// </summary>
		/// <param name="id"></param>
        /// <returns></returns>
		public virtual async Task<HttpResponseMessage> DeleteAsync(Int32 id)
		{
			return await HttpClient.DeleteAsync("api/Values/" + id);
		}

		#endregion

		public void Dispose()
        {
            HttpClient.Dispose();
        }
	}

}

