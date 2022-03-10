# Troubleshooting flow chart
```mermaid
flowchart TD;
    Root[Yes or no?]-->|Yes|ChildA
    Root-->|No|ChildB
    ChildA[Yes indeed]
    ChildB[No way]
```