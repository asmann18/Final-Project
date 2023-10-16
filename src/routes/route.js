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
            path:"productDetail/:id",
            element:<ProductDetail/>

        },
        {
            path:"register",
            element:<Register/>
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
                path:"products",
                element:<Products/>
            },
            {
                path:"productCategories",
                element:<ProductCategories/>
            },
            {
                path:"brands",
                element:<Brands/>
            },
            {
                path:"aromas",
                element: <Aromas/>
            },

            {
                path:"blogs",
                element:<Blogs/>
            },
            {
                path:"blogCategories",
                element:<BlogCategories/>
            },

            {
                path:"parts",
                element:<Parts/>
            },
            {
                path:"moves",
                element:<Moves/>
            }

        ]
}
]