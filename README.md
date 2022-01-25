# SaaSCLI

##### Develop by: Jairo Blanco Aldao
##### IDE: Visual studio 2022
##### Version: .Net 6

## Description

This is the provided solution for the a Technical Test. In this case the test was splitted in two parts: 

1. Database
2. Code 

Database solution will be paste on here and for the code some notes will be added to complete the solution.

## Database
Instead of a MYSQL database a MSSQL has been used.

1 ->
``` sql
select * from [test].[dbo].[users] where [id] in (3,2,4)
```

2 -> 
``` sql
SELECT u.first_name, u.last_name, 
    SUM(CASE WHEN l.status = 2 THEN 1 ELSE 0 END) as basic,
    SUM(CASE WHEN l.status = 3 THEN 1 ELSE 0 END) as premium
    from [test].[dbo].[users] as u
    inner join [test].[dbo].[listings] as l on u.id = l.user_id
    GROUP BY u.first_name, u.last_name
```

3 -> 
``` sql
SELECT u.first_name, u.last_name, 
    SUM(CASE WHEN l.status = 2 THEN 1 ELSE 0 END) as basic,
    SUM(CASE WHEN l.status = 3 THEN 1 ELSE 0 END) as premium
    from [test].[dbo].[users] as u
    inner join [test].[dbo].[listings] as l on u.id = l.user_id
    GROUP BY u.first_name, u.last_name
    HAVING SUM(CASE WHEN l.status = 3 THEN 1 ELSE 0 END) > 0
```

4 -> 
 
``` sql
  SELECT u.first_name, u.last_name, c.currency, COUNT(c.price) as revenue
    FROM [test].[dbo].[users] as u
    INNER JOIN [test].[dbo].[listings] as l on u.id = l.user_id
    INNER JOIN [test].[dbo].[clicks] as c on c.listing_id = l.id
    GROUP BY u.first_name, u.last_name, c.currency, c.created
    HAVING YEAR(c.created)  = '2013'
```

5 -> 
``` sql
INSERT INTO [test].[dbo].[clicks] VALUES (40,3,4.00,'USD','2016-09-15 16:18:43')
SELECT MAX(id) from [test].[dbo].[clicks]
```

6 -> 
``` sql
SELECT DISTINCT(l.name) from [test].[dbo].[listings] as l
    INNER JOIN [test].[dbo].[clicks] as c on l.id = c.listing_id
    where YEAR(c.created) != '2013'
```

7 ->  
``` sql 
SELECT YEAR(c.created), COUNT(l.id) as total_listings_clicked, COUNT(DISTINCT u.id) as total_vendors_affected
  FROM [test].[dbo].[users] as u
  INNER JOIN [test].[dbo].[listings] as l on u.id = l.user_id
  INNER JOIN [test].[dbo].[clicks] as c on c.listing_id = l.id
  GROUP BY c.created
```

8 -> 
``` sql 
SELECT u.first_name, u.last_name, string_agg(l.name, ', ') as listing_names
  FROM [test].[dbo].[users] as u
  INNER JOIN [test].[dbo].[listings] as l on u.id = l.user_id
  where u.[status] = 2
  GROUP BY u.first_name, u.last_name
```

## Code
For the design of the solution I been trying to implement a monorepo but there is no solution separation, all components are in the same solution. 
I would like to implement also acceptance test to complete the testing for this PoC.

The code is splitted into 4 tiers:

  1. Presentation: Anything related to give output to the user
  2. Core: Contains anything related with the bussines logic, application structure, behaviour, etc.
  3. Infrastructure: Data persistance with an abstraction layer to allow multiple implementations.
  4. Libraries: Shared components
 
 ### Good Tips
 1. All libraries has their own IoC to provide a way to autoinject then.
 2. All components are Test Friendly providing an abstraction i.e. ISystemIO 
 3. SOLID patterns where heavily applicated.
 4. Autowired pattern provide so new commands can be easily added.
 5. No external libraries for command parsing or executiong where used.
 
 ### Bad Tips
 1. No logger injected.
 2. No settings file provide.
 3. Missing Acceptance tests.
 4. Command input flakyness: missing validatio, flaky parsing.
 5. Yaml parser not properly implemented.
 6. Not a real CLI/bash.
 ## Considerations:
 
 ### Instalation steps
 [SaaSCLI v1.0.0](https://github.com/Arthus15/SaaSCLI/releases/tag/Final)
 
 ### How to run your code/test
 Easiest way will be open visual studio and running the integration test/Run the SaaSCLi solution. 
 **yaml file attributes where wrong named, correction was made
 
 ### Was it you first time writing a unit test, using a particular framework, etc?
 No, in this case because of time I wasn't able to implement an isolation pool of context for the test to run in parallel. In any case I don't think is necesary. 
 
 ### What would you have done differently if you had had more time?
 1. Context isolation
 2. Settings
 3. A proper Yaml parser
 4. Acceptance tests
 5. More strong validations
 6. The desing could be smoother and simpler
 7. Build Automation
 
 ## Comments
 I want to apologize for not beeing able to do the test in time, due to this I tried to commit in any new feature so the historical can approximated the time taken 
 (at least in the code design).
 
 
 
 
