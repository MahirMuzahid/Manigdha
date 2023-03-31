namespace PostService.Service
{
    public class Query
    {
        [UseProjection]
        public Response Test()
        {
            var s = "It is working Fine";
            return new Response(s, System.Net.HttpStatusCode.OK);
        }
    }
}
