using System.Net.Http.Json;
using System.Text;
using TFL.Common.Model;

var command = string.Empty;

do
{
    command = Console.ReadLine() ?? "";
    var enteredText = command.ToLower();

    using (var client = new HttpClient())
    {
        RoadModel summary = null;
        //  client.BaseAddress = new Uri(request.Uri);
        client.DefaultRequestHeaders.Accept.Clear();

        var response = await client.GetAsync($"https://localhost:7111/api/Road?id={enteredText}");

        if (response.IsSuccessStatusCode)
        {
            summary = await response.Content.ReadFromJsonAsync<RoadModel>();

        }

        var result = new StringBuilder($"The status of the  {summary.RoadDetails[0].DisplayName}is as follows ");
        result.AppendLine();
        result.Append($"Road Status is : {summary.RoadDetails[0].StatusSeverity} ");
        result.AppendLine();
        result.Append($"Road Status Description is  : {summary.RoadDetails[0].StatusSeverityDescription} ");

        System.Console.WriteLine(result);

    }



} while (command != "exit");
