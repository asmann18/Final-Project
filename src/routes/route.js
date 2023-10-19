import Home from "../pages/site/Home/Home"
import Blog from "../pages/site/Blog/Blog"
import Contact from "../pages/site/Contact/Contact"
import Moves from "../pages/site/Moves/Moves"
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
            path: "contact",
            element: <Contact />
        },
        {
            path: "shop",
            element: <Shop />
        },
        {
            path: "moves",
            element: <Moves />
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
                element:<ProductCategoriesUpdate/>
            },
            {
                path:"productCategories/delete/:id",
                element:<ProductCategoriesDelete/>
            },
            {
                path:"productCategories/:id",
                element:<ProductCategoriesDetail/>
            },





            {
                path: "brands",
                element: <Brands />
            },{
                path:"brands/create",
                element:<BrandsCreate/>
            },
            {
                path:"brands/update/:id",
                element:<BrandsUpdate/>
            },
            {
                path:"brands/delete/:id",
                element:<BrandsDelete/>
            },
            {
                path:"brands/:id",
                element:<BrandsDetail/>
            },





            {
                path: "aromas",
                element: <Aromas />
            },

            {
                path: "blogs",
                element: <Blogs />
            },
            {
                path: "blogCategories",
                element: <BlogCategories />
            },

            {
                path: "parts",
                element: <Parts />
            },
            {
                path: "moves",
                element: <Moves />
            }

        ]
}
]