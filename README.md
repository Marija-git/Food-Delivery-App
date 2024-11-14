# Food Delivery App - Project Overview

- Technologies: EntityFramework, MS SQL Server, ASP.NET MVC, C#, HTML, CSS.
- This project is a system for managing users, orders, and delivery for a food delivery service. Users can be categorized into **Unregistered Users**, **Logged-In Users**, **Consumers**, **Delivery Persons**, and **Admins**, each with distinct roles and functionalities.

---

**Project Description and User Roles**

### **Unregistered User**

- **Access the homepage**: Unregistered users can either log in (if they are already registered) or create an account to join the system.
- **Login**: Login is performed via email and password.
- ![login_form](https://github.com/user-attachments/assets/25a4dddb-ce82-4f96-81fe-ab34f710bcea) ![signup_form](https://github.com/user-attachments/assets/9c970303-38fb-4944-bcb9-f508ffb30887)

### **Logged-In User**

- **Redirected to homepage**: After successfully logging in, they are redirected to the homepage, which includes specific elements depending on their role.
- **Update Profile**: Can update personal information on the profile view page.

### **Admin**

- **User Registration Verification**: After user registration, the administrator must approve the registration/verify the registration for delivery persons. - Has the ability to review data, and can accept or reject certain requests. After acceptance, the profile becomes active. - Verification is not required for regular consumers.
- **Manage Delivery Persons**: The administrator sees a list of delivery persons and their statuses, can approve or reject their status, and see which ones are approved.
- **Order Management**:The administrator has access to all orders, both in progress and completed, as well as their status. For orders in progress, a countdown until delivery is not required.
- **Product Management**: The admin adds new products sold by the restaurant. A product should have a name, price, and ingredients.

**Delivery Person:**

- **Profile Verification Status**: The user/potential delivery person has an indication of the verification process status on their profile (request being processed, accepted, rejected).
- **Order Management**: After logging in, the delivery person has access to:

  - Profile
  - View new orders
  - View past orders
  - Current order

- **Order Acceptance**: The delivery person sees a list of new orders waiting for a delivery person and can accept pending orders.It is prevented for delivery person to accept multiple orders at the same time.
- **Previous Orders**: The delivery person can view their previous orders.

### **Consumer**

- **Profile Update**: After logging in, the consumer has the following option:
- **Create Orders**: Consumers can place a new order, specifying:

  - Quantity
  - Delivery address
  - Comments
  - Price

- **Order Details**:Can order one or more products. The price is calculated based on the products ordered and the quantity, plus the delivery fee, which is always the same.
- **Order Acceptance**: When the consumer places an order, they wait for the delivery person to accept the order.
- **View Past Orders**:The consumer can view the list of their previous orders.

**Solution Description**

### **Authentication**

During the login process, the entered credentials are validated against the values stored in the database. A session object is used to store data about the logged-in user. When logging in, the user is added to the session.

### **Authorization**

Authorization is performed through a simple condition check based on the user's role (user type).
