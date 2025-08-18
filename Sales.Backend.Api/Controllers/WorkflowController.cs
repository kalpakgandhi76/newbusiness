using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]/trigger")]
public class WorkflowController : ControllerBase
{
    private readonly ILogger<WorkflowController> _logger;   

    public WorkflowController(ILogger<WorkflowController> logger)
    {
        _logger = logger;   
    }
   
    [HttpGet()]
    public async Task<ActionResult> TriggerAsync()
    {
        _logger.LogInformation("Trigger Action is being called...");
        string owner = "kalpakgandhi76";
        string repo = "newbusiness";
        string workflowFile = "gw-qualitygates-demo.yaml";
        string branch = "main";

        // Personal Access Token
        string pat = "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";

        // Workflow inputs (if defined in workflow_dispatch)
        string jsonBody = @"{
            ""ref"": """ + branch + @"""         
        }";

        // GitHub API URL
        string url = $"https://api.github.com/repos/{owner}/{repo}/actions/workflows/{workflowFile}/dispatches";

        using (HttpClient client = new())
        {
            // GitHub requires a user-agent header       
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", pat);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp/1.0");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Workflow triggered successfully!");
                }
                else
                {
                    Console.WriteLine($"Failed to trigger workflow. Status code: {response.StatusCode}");
                    string respContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + respContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


       return Ok("Trigger Action executed successfully.");
    
    }   
}
