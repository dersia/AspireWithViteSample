# Sample Project Aspire+Vite

This repo is just a sample project for issue [#1898](https://github.com/dotnet/aspire/issues/1898#issuecomment-1913028840)

### Setup

yarn:

```bash
git clone https://github.com/dersia/AspireWithViteSample.git
cd AspireWithViteSample/AspireWithViteSample.Frontend
yarn
```

npm:

```bash
git clone https://github.com/dersia/AspireWithViteSample.git
cd AspireWithViteSample/AspireWithViteSample.Frontend
npm i
```

!set the environment variable PORT before you start!
Powershell:
`$env:PORT = 3000`
Bash:
`PORT=300`


start:

```bash
yarn dev
``

```bash
npm run dev
```

### Issue

There are 2 Projects:

* ASPNET Web Api called Backend.
  This is a basic Web Api project, just created from template, nothing changed
* Vite React-Ts called Frontend
  This is a basic Vite project created with `yarn create-vite --template react-ts`

The solution also contains a .NET Aspire Project.
In the Aspire Project both the backend and the frontend are added to the builder.
The Backend is added as a Reference (`WithReference(backend)`) to the Frontend.
Running the Aspire Project brings up both Backend and Frontend and the Backend Service url is added to the Environment Variables as expected.
The Frontend project uses vite in the App.tsx to load the Backend Url from the Environment Variables
`const backendurl = import.meta.env.services__backend__1` and outputs it `<p className='read-the-docs'>Backend url: {backendurl}</p>`.

To start this using Aspire make sure you have set `AspireWithViteSample.AppHost` as the starting project and hit F5.

### Vite Environment Variables

Vite only takes Environment Variables into consideration that are prefixed with `VITE_`. This is for security purposes to make sure that no environment variables are exposed, that are not supposed to be exposed.
If you add the environment variable manually
Powershell:
`$env:VITE_services__backend__1 = http://localhost:backendport`
Bash:
`VITE_services__backend__1=http://localhost:backendport`
and change 
`const backendurl = import.meta.env.services__backend__1`
to
`const backendurl = import.meta.env.VITE_services__backend__1`

and start the vite app it all works as expected and the backendurl will be displayed