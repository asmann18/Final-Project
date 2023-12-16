import Home from "../pages/site/Home/Home"
import Blog from "../pages/site/Blog/Blog"
import Contact from "../pages/site/Contact/Contact"
import Moves from "../pages/admin/move/Moves"
import Shop from "../pages/site/Shop/Shop"
import AdminRoot from "../pages/admin/adminRoute/AdminRoot";
import Dashboard from "../pages/admin/dashboard/Dashboard";
import SiteRoot from "../pages/site/siteRoute/SiteRoot"
import Error from "../pages/error/Error"
import Register from "../pages/site/Account/Register"
import ProductDetail from "../pages/site/Shop/ProductDetail"
import Products from "../pages/admin/product/Products"
import ProductCategories from "../pages/admin/productCategory/ProductCategories"
import Brands from "../pages/admin/brand/Brands"
import Aromas from "../pages/admin/aroma/Aromas"
import Blogs from "../pages/admin/blog/Blogs"
import BlogCategories from "../pages/admin/blogCategory/BlogCategories"
import Parts from "../pages/admin/part/Parts"
import ProductsDetail from "../pages/admin/product/ProductsDetail"
import ProductsUpdate from "../pages/admin/product/ProductsUpdate"
import ProductDelete from "../pages/admin/product/ProductDelete"
import ProductsCreate from "../pages/admin/product/ProductsCreate"
import ProductCategoriesCreate from "../pages/admin/productCategory/ProductCategoriesCreate"
import ProductCategoriesUpdate from "../pages/admin/productCategory/ProductCategoriesUpdate"
import ProductCategoriesDelete from "../pages/admin/productCategory/ProductCategoriesDelete"
import ProductCategoriesDetail from "../pages/admin/productCategory/ProductCategoriesDetail"
import BrandsCreate from "../pages/admin/brand/BrandsCreate"
import BrandsUpdate from "../pages/admin/brand/BrandsUpdate"
import BrandsDelete from "../pages/admin/brand/BrandsDelete"
import BrandsDetail from "../pages/admin/brand/BrandsDetail"
import AromasCreate from "../pages/admin/aroma/AromasCreate"
import AromasUpdate from "../pages/admin/aroma/AromasUpdate"
import AromasDelete from "../pages/admin/aroma/AromasDelete"
import BlogsCreate from "../pages/admin/blog/BlogsCreate"
import BlogsUpdate from "../pages/admin/blog/BlogsUpdate"
import BlogsDelete from "../pages/admin/blog/BlogsDelete"
import BlogsDetail from "../pages/admin/blog/BlogsDetail"
import BlogsCategoriesCreate from "../pages/admin/blogCategory/BlogsCategoriesCreate"
import BlogCategoriesUpdate from "../pages/admin/blogCategory/BlogCategoriesUpdate"
import BlogCategoriesDelete from "../pages/admin/blogCategory/BlogCategoriesDelete"
import PartsCreate from "../pages/admin/part/PartsCreate"
import PartsUpdate from "../pages/admin/part/PartsUpdate"
import PartsDelete from "../pages/admin/part/PartsDelete"
import PartsDetail from "../pages/admin/part/PartsDetail"
import MovesDetail from "../pages/admin/move/MovesDetail"
import MovesCreate from "../pages/admin/move/MovesCreate"
import MovesUpdate from "../pages/admin/move/MovesUpdate"
import MovesDelete from "../pages/admin/move/MovesDelete"
import MovesPage from "../pages/site/Moves/Moves"
import MoveDetail from "../pages/site/Moves/MoveDetail"
import BlogDetail from "../pages/site/Blog/BlogDetail"
import Basket from "../pages/site/Basket/Basket"
import Orders from "../pages/site/Orders/Orders"
import OrdersAdmin from "../pages/admin/order/Orders"
import OrderUpdate from "../pages/admin/order/OrderUpdate"
import Users from "../pages/admin/user/Users"
import UserUpdate from "../pages/admin/user/UserUpdate"
export const ROUTES = [{
    path: "/",
    element: <SiteRoot />,
    children: [
        {
            path: "",
            element: <Home />
        },
        {
            path: "blog",
            element: <Blog />
        },
        {
            path:"blog/:id",
            element:<BlogDetail/>
        },

        {
            path: "contact",
            element: <Contact />
        },
        {
            path: "shop",
            element: <Shop />
        },
        {
            path: "moves",
            element: <MovesPage />
        },
        {
            path:"moves/:id",
            element:<MoveDetail/>
        },


        {
            path: "productDetail/:id",
            element: <ProductDetail />

        },
        {
            path: "register",
            element: <Register />
        },
        {
            path:"basket",
            element:<Basket/>
        },
        {
            path:"orders",
            element:<Orders/>
        },
        {
            path: "*",
            element: <Error />
        }
    ]
},
{
    path: "/admin",
    element: <AdminRoot />,
    children:
        [
            {
                path: "",
                element: <Dashboard />
            },
            {
                path: "products",
                element: <Products />

            },

            {
                path: "products/:id",
                element: <ProductsDetail />
            },
            {
                path: "products/update/:id",
                element: <ProductsUpdate />
            },
            {
                path: "products/delete/:id",
                element: <ProductDelete />
            },
            {
                path: "products/create",
                element: <ProductsCreate />
            },



            {
                path: "productCategories",
                element: <ProductCategories />
            },
            {
                path: "productCategories/create",
                element: <ProductCategoriesCreate />
            },
            {
                path: "productCategories/update/:id",
                element: <ProductCategoriesUpdate />
            },
            {
                path: "productCategories/delete/:id",
                element: <ProductCategoriesDelete />
            },
            {
                path: "productCategories/:id",
                element: <ProductCategoriesDetail />
            },





            {
                path: "brands",
                element: <Brands />
            }, {
                path: "brands/create",
                element: <BrandsCreate />
            },
            {
                path: "brands/update/:id",
                element: <BrandsUpdate />
            },
            {
                path: "brands/delete/:id",
                element: <BrandsDelete />
            },
            {
                path: "brands/:id",
                element: <BrandsDetail />
            },





            {
                path: "aromas",
                element: <Aromas />
            },
            {
                path: "aromas/create",
                element: <AromasCreate />
            },
            {
                path: "aromas/update/:id",
                element: <AromasUpdate />
            },
            {
                path: "aromas/delete/:id",
                element: <AromasDelete />
            },






            {
                path: "blogs",
                element: <Blogs />
            },
            {
                path: "blogs/create",
                element: <BlogsCreate />
            },
            {
                path: "blogs/update/:id",
                element: <BlogsUpdate />
            },
            {
                path: "blogs/delete/:id",
                element: <BlogsDelete />
            },
            {
                path: "blogs/:id",
                element: <BlogsDetail />
            },
          




            {
                path: "blogCategories",
                element: <BlogCategories />
            },
            {
                path: "blogCategories/create",
                element: <BlogsCategoriesCreate />
            },
            {
                path:"blogCategories/update/:id",
                element:<BlogCategoriesUpdate/>
            },
            {
                path:"blogCategories/delete/:id",
                element:<BlogCategoriesDelete/>
            },







            {
                path: "parts",
                element: <Parts />
            },
            {
                path:"parts/create",
                element:<PartsCreate/>
            },
            {
                path:"parts/update/:id",
                element:<PartsUpdate/>
            },  
            {
                path:"parts/delete/:id",
                element:<PartsDelete/>
            },
            {
                path:"parts/:id",
                element:<PartsDetail/>
            },







            {
                path: "moves",
                element: <Moves />
            },
            {
                path:"moves/:id",
                element:<MovesDetail/>
            },
            {
                path:"moves/create",
                element:<MovesCreate/>
            },
            {
                path:"moves/update/:id",
                element:<MovesUpdate/>
            },
            {
                path:"moves/delete/:id",
                element:<MovesDelete/>

            },
            {
                path:"orders",
                element:<OrdersAdmin/>
            },
            {
                path:"orders/update/:id",
                element:<OrderUpdate/>
            },
            {
                path:"users",
                element:<Users/>
            },  {
                path:"users/update/:id",
                element:<UserUpdate/>
            }

        ]
}
]