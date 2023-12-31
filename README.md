<!-- Top of your README.md -->
<a name="top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a><img src="https://i.imgur.com/dZVNWFP.png" alt="Logo" width="80" height="80"></a>

 ######  <h3 align="center">Vault Homework in C#</h3>

  <p align="center">
    Well-documented OOP console app to solve an algorithm
    <br />
    <a href="https://i.imgur.com/z6rTxX1.png"><strong>Codecoverage »</strong></a>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-solution">About The Solution</a></li>
    <li><a href="#getting-started">Getting Started</a></li>
    <li><a href="#xunit-tests">xUnit Tests</a></li>
    <li><a href="#code-coverage">Code coverage</a></li>
  </ol>
</details>

<!--About The Solution -->
## About The Solution

I found this as a perfect opportunity to use the Template method as a skeleton of the algorithm. There are two different approaches to coding:
* General: The least language-specific approach
* C# specific: Linq

Each approach solves the algorithmic part in 3 steps

* Features:
    * Multi-stage docker file 1.2gb reduced to 140mb
    * The most efficient and highly customizable File read operation suitable for large file scenarios
        * 100mb vs 500mb file simulation: 
        ```csharp
            File.ReadAllLines(filePath)
            // 100mb file: 1.7gb RAM consumed
            // 500mb file: OutOfMemoryException
    
            // The variation I used: 
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            // 100mb file: 5mb RAM consumed
            // 500mb file: 30mb RAM consumed
            // Why is that?
            // While the first option loads everything to the memory.
            // Mine reads line by line and replaces the previously used one with the new one. 
            // Therefore, It always uses as much space as the current line requires.
        ```

<!-- GETTING STARTED -->
## Getting Started

There are two recommended ways to run this project.
* Run the project from your IDE, preferably Visual Studio 2022
    * You can add your input.txt:\
            1. Go to the VaultHomework\VaultHomework folder where is VaultHomework.csproj located
      and add your file.\
        2. Specify the file location with CLI:
        ```sh
        dotnet run yourfilename.txt
        ```
* Docker container: Navigate to the root folder of the repo where Dockerfile is located.
1. Build the docker image: 
    ```sh
    docker build -t vaulthomework .
    ```
2. Run the docker container:
    ```sh
    docker run --rm vaulthomework
    ```

<!-- Code coverage -->
### Code coverage 
* Manually opening from your local env. <a href="https://i.imgur.com/z6rTxX1.png">» VaultHomework/coveragereport/index.html</a>
* How to generate a new report?
1. Run tests:
    ```sh
    dotnet test --collect:"XPlat Code Coverage"
    ```
2. Install reportgenerator:

    ```sh
    dotnet tool install -g dotnet-reportgenerator-globaltool
    ```
3. Generate Code coverage:
    ```sh
    reportgenerator -reports:'**\coverage.cobertura.xml' -targetdir:"coveragereport"-reporttypes:Html
    ```

<!-- xUnit Tests -->
### xUnit Tests

In total, there are 30 unit tests, distributed equally.
<p align="right">(<a href="#vault-homework-in-c">back to top</a>)</p>

