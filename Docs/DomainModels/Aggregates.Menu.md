# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}

```

```json
{
  "id": "000000000-00000-000000-000000",
  "name": "Yummy Menu",
  "description": "A menu with yummy menu",
  "averageRate": 4.5,
  "hostId": "000000000-00000-0-0-0-0---0000000",
  "dinnerIds": ["000000-000--0000000", "00000-000-000000-000"],
  "sections": [
    {
      "id": "0000000-000--00000",
      "name": "Appetizers",
      "items": [
        {
          "id": "000000-0000-0000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "prices": 5.99
        }
      ]
    }
  ],
  "createdDateTimes": "",
  "menuReviewIds": ["00000000-000-000000", "000000-000-0000"]
}
```
