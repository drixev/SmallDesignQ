# Small Design - Q

A small project to reflect division logic analize from sequencial number generated from 0 to input SampleSize and divide using input1 and input2.

## Design decision
 
To complete the task I decided use a MonoRepo for both, backend and frontend projects. 

Each project has its own design. I would explain them as follow:

### Backend

Backend will be created using Clean Architecture for clear separation of concerns. This allow us create or add more domains. I'm just thinking as scalable software.

***Tech Stack***

- Net10
- FluentValidation

I will work in the following estructure:

```bash

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

```

### Frontend

Frontend will be created using domain estructure for clear separation of concerns. This allow use working on specific feature/domain without affects others.
For now, I just only consider the following stack

***Tech Stack***
- Vite 
- React
- Tanstack
- Zod
- Zustand
- TanStack query/route


