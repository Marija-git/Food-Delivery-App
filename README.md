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
- ![admin_page](https://github.com/user-attachments/assets/7f5c3b78-4571-4265-85ce-55ca98b65509) ![reg_req_delivery](https://github.com/user-attachments/assets/de46b72a-f0e1-4340-9c6a-8a8f4b500cb9) ![add_new_article](https://github.com/user-attachments/assets/2b78ed06-fc7d-4c2c-9470-31746f603c81)

**Delivery Person:**

- **Profile Verification Status**: The user/potential delivery person has an indication of the verification process status on their profile (request being processed, accepted, rejected).
- **Order Management**: After logging in, the delivery person has access to:

  - Profile
  - View new orders
  - Current order

- **Order Acceptance**: The delivery person sees a list of new orders waiting for a delivery person and can accept pending orders.It is prevented for delivery person to accept multiple orders at the same time.
- ![delivery_person_page](https://github.com/user-attachments/assets/c17edd7c-7a03-4d81-8f7d-1067bf12f53c) ![check_verification_status](https://github.com/user-attachments/assets/1c866d03-fdd2-40fc-8065-b5ab84c9f1c1) ![status_rejected](https://github.com/user-attachments/assets/f5142bae-c07e-4aa0-a686-16482a19fdd6)

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
- ![consumer_page](https://github.com/user-attachments/assets/00899968-847d-4066-af7d-bcf6cf574ccd) ![order food](https://github.com/user-attachments/assets/a52c7817-77d4-421a-9f75-c4eecf8b803b) ![update_profile](https://github.com/user-attachments/assets/39025e3d-68f9-458e-84cb-1307dcb34c48)

**Solution Description**

### **Authentication**

During the login process, the entered credentials are validated against the values stored in the database. A session object is used to store data about the logged-in user. When logging in, the user is added to the session.

### **Authorization**

Authorization is performed through a simple condition check based on the user's role (user type).
