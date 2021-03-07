# Serialized .NET client

The official .NET client for [Serialized](https://serialized.io).

[![](https://tokei.rs/b1/github/serialized-io/client-dotnet)](https://github.com/serialized-io/client-dotnet)
[![Actions Status](https://github.com/serialized-io/client-dotnet/workflows/Build%20&%20Test/badge.svg)](https://github.com/serialized-io/client-dotnet/actions)

The client classes are generated using [AutoRest 3.1.2](https://github.com/Azure/autorest) and our [Swagger JSON](https://serialized.io/api.json) file.

## 💡 Getting Started

Register for a free account at https://serialized.io to get your access keys to the API (if you haven't already).


## Adding dependency

Grab the latest [release package](https://github.com/serialized-io/client-dotnet/packages/).
You will have to configure your CLI for use with Github packages if you did not already do so.
More info [here](https://docs.github.com/en/free-pro-team@latest/packages/using-github-packages-with-your-projects-ecosystem/configuring-dotnet-cli-for-use-with-github-packages).

## Configuring the client

The core object you'll interact with to add events to a collection is the `SerializedClient` object. After creating a `SerializedClient` instance, you'll want to provide it with your Serialized API keys. gsProvider` instance that contains details about your project id, keys, and optionally a different root URL for Keen.IO's API.

```
using SerializedClient;
using SerializedClient.Models;
...
var client = new Serialized();
client.HttpClient.DefaultRequestHeaders.Add("Serialized-Access-Key", <your-access-key>);
client.HttpClient.DefaultRequestHeaders.Add("Serialized-Secret-Access-Key", <your-secret-access-key>);
```

## Usage

For a simple usage example, please see the [ScenarioTest](https://github.com/serialized-io/client-dotnet/blob/main/SerializedClientTest/ScenarioTest.cs).

