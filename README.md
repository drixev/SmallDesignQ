# Small Design - Q

A small project to reflect division logic analize from sequencial number generated from 0 to input SampleSize and divide using input1 and input2.

## Design decision
 
To complete the task I decided use a MonoRepo for both, backend and frontend projects. 

Each project has its own design. I would explain them as follow:


**Fake credentials**
[check here](backend/src/GenerateService.Api/GenerateService.Api.http)

```bash
# request Auth
username: anything # write whatever you want
password: FakeAdmin # just tests, 

```


### Backend

Backend will be created using Clean Architecture for clear separation of concerns. This allow us create or add more domains. I'm just thinking as scalable software.

***Tech Stack***

- Net10
- FluentValidation

I will work in the following estructure:

```bash
|-src
    |-Api
    |---Auth
    |---Generate
    |-Application
    |---GenerateService
    |---DTOs
    |---Ports
    |---Validators
    |-Domain
    |---SampleSizeEntity
    |-Infraestructure
    |---Security
    |-----Authentication
    |-----Configuration
|-tests
|--Services
|--Validators
```

**Run**
```bash
## run the backend
dotnet run

## run he tests
dotnet test
```

### Frontend

Frontend will be created using domain estructure for clear separation of concerns. This allow use working on specific feature/domain without affects others.
First I decided make it simple, but went I was working on it I decided on the fly add more libs

***Tech Stack***
- Vite 
- React
- Tanstack
- Zod
- Zustand
- TanStack query/router/plugin
- React Hook form
- Hook forms
- tailwindcss
- pnpm as package manager


**Run**
```bash
## install dependencies
pnpm install
## run the backend
pnpm run dev
```

## LICENSE
MIT
