# Welcome to JOI Delivery

JOI Delivery is built for real life. For the young professional who gets home late and doesn’t have the energy to cook. For the student with an exam tomorrow and an empty fridge tonight. These aren’t exceptions — they’re everyday moments. That’s why JOI Delivery brings food and groceries to your door, fast, fresh, and right when you need them.

Customers struggle with:

- Cluttered browsing experiences that don’t understand their preferences.
- Limited customization when ordering meals or groceries.
- Unclear order status or delivery timelines.
- Poor payment experience, or failed checkouts.
- Lack of timely feedback channels to report a bad experience or appreciate a good one.

JOI Delivery was built not just as another delivery app, but as a thoughtful, technology-first platform that reimagines how essentials reach customers in the most seamless way.

# Introducing JOI Delivery

JOI Delivery, launched in 2024, is a hyperlocal delivery app designed to bring food and groceries to your doorstep in under 45 minutes. With the tagline "Speed meets convenience," it connects customers to nearby restaurants and stores through a seamless digital experience. The app solves the hassle of long wait times and limited local options by offering real-time tracking, instant order updates, and a wide network of trusted vendors.

## Business Goals

- Differentiated Value Proposition & Niche Dominance
- Deliver Unmatched Customer Experience & Loyalty
- Superior Operational Efficiency & Cost Advantage
- Robust & Engaged Partner Ecosystem

## Why they need help

As JOI Delivery continues to grow and serve more neighborhoods, we’re scaling our platform to handle increasing demand, enhance user experience, and support smarter delivery logistics. They're looking for passionate developers to help us build robust, efficient, and scalable solutions that power everything from order placement to real-time tracking.
Your expertise will directly impact how quickly and reliably customers receive their essentials—and how smoothly local vendors and delivery partners operate within our ecosystem.

### Users/Customers

Sample user profiles are available in the repository to support development and testing scenarios.

| UserId  | FirstName | LastName |
| ------- | --------- | -------- |
| user101 | John      | Doe      |

### Stores

Sample store data seeded for development purposes only.

| StoreId  | OutletName     |
| -------- | -------------- |
| store101 | Fresh Picks    |
| store102 | Natural Choice |

### Grocery Products

Dummy Products for Stores to sell and users to buy from.

| ProductId  | ProductName | StoreRefId |
| ---------- | ----------- | ---------- |
| product101 | Wheat Bread | store101   |
| product102 | Spinach     | store101   |
| product103 | Crackers    | store101   |

## API

Below is a list of API endpoints with their respective input and output. Please note that the application needs to be running for the following endpoints to work. For more information about how to run the application, please refer to run the application section above.

### Add Product to Cart

```http
POST /cart/product
Content-Type: application/json
```

Request Body

```json
{
  "userId": "user101",
  "productId": "product101",
  "outletId": "store101"
}
```

Response Body

```json
{
  "cart": {
    "cartId": "cart101",
    "outlet": null,
    "products": [
      {
        "productId": "product103",
        "productName": "Crackers",
        "mrp": 10.5,
        "sellingPrice": null,
        "weight": 500,
        "expiryDate": 0,
        "threshold": 10,
        "availableStock": 30,
        "discount": null,
        "store": {
          "name": "Fresh Picks",
          "description": null,
          "outletId": "store101",
          "inventory": []
        }
      }
    ],
    "user": null
  },
  "product": {
    "productId": "product103",
    "productName": "Crackers",
    "mrp": 10.5,
    "sellingPrice": null,
    "weight": 500,
    "expiryDate": 0,
    "threshold": 10,
    "availableStock": 30,
    "discount": null,
    "store": {
      "name": "Fresh Picks",
      "description": null,
      "outletId": "store101",
      "inventory": []
    }
  },
  "sellingPrice": null
}
```

### View Cart

```http
GET /cart/view?userId=user101
```

Response Body

```json
{
  "cartId": "cart101",
  "outlet": null,
  "products": [],
  "user": null
}
```

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

### Installation & Running

1.  **Clone the repository:**

    ```bash
    git clone git@github.com:techops-recsys-lateral-hiring/developer-joi-delivery-csharp.git
    cd developer-joi-delivery-csharp
    ```

2.  **Restore dependencies:**
    This command installs the necessary NuGet packages defined in the project.

    ```bash
    dotnet restore
    ```

3.  **Run the application:**
    This command builds and starts the API server.
    ```bash
    dotnet run
    ```
    The application will be running on **http://localhost:8080**. Once running, the API endpoints below will be available.
