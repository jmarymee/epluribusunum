using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace EPluribusUnumEndpoint.Controllers
{
    using Models;
    public class ValuesController : ApiController
    {
        //private workItem aWorkItem; //  ePluribusUnum work Item

        // GET api/values
        public async Task<ActionResult> Get()
        {


            var items = await DocumentDBRepository<WorkItem>.GetItemsAsync(d => !d.Completed);

            string _JsonStr = JsonConvert.SerializeObject(items);
                JsonResult _itemsJson = new JsonResult();
                _itemsJson.Data = _JsonStr;

                return _itemsJson;
  

        }

        // GET api/values/5
        public async Task<ActionResult> Get(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WorkItem _item = await DocumentDBRepository<WorkItem>.GetItemAsync(id);
            if (_item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            string _JsonStr = JsonConvert.SerializeObject(_item);
            JsonResult _anItemJson = new JsonResult();
            _anItemJson.Data = _JsonStr;

            return _anItemJson;

            // need to return the item.
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }


        // PUT api/values/5
        public void Put(String id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }


}
