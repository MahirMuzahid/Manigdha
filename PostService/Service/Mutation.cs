namespace PostService.Service
{
    public class Mutation
    {
        public Response Test( string s)
        {
            return new Response(s, System.Net.HttpStatusCode.OK);
        }
    }
}
