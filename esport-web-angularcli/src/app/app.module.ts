import { NgModule, CUSTOM_ELEMENTS_SCHEMA }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { RouterModule, Routes} from "@angular/router";
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';


import {LoginComponent} from './login/login.component';
import {MainPanelComponent} from './mainPanel/mainPanel.component';
import {CartComponent} from './cart/cart.component';
import {ReviewComponent} from './review/review.component';
import {PendingReviewComponent} from './review/pendingReview.component';
import {ProductReviewComponent} from './product/productReviews.component'
import {CartHistoryComponent} from './cart/cartHistory.component';
import {UserFormComponent} from './shared/userForm.component';
import {CartItemComponent} from './shared/cartItem.component';
import {UserAccountComponent} from './user/userAccount.component';
import { SharedRoleComponent } from './shared/sharedRole.component';
import { SharedCategoryComponent } from './shared/sharedCategory.component';
import { AddCategoryComponent } from './category/addCategory.component';
import { ShowCategoriesComponent } from './category/showCategories.component';
import { UpdateCategoryComponent } from './category/updateCategory.component';
import { AddProductInCategoryComponent } from './category/addProductInCategory.component';
import { RemoveProductFromCategoryComponent } from './category/removeProductFromCategory.component';
import { AddOrRemoveProductInCategory } from './shared/addOrRemoveProductInCategory.component';
import { AddRoleComponent } from './role/addRole.component';
import { UpdateRoleComponent } from './role/updateRole.component';
import { ShowRolesComponent } from './role/showRoles.component';
import { AddUserComponent } from './user/addUser.component';
import { AddProductComponent } from './product/addProduct.component';
import { SharedProductComponent } from  './shared/sharedProduct.component';
import { ShowProductsComponent} from './product/showProducts.component';
import { UpdateProductComponent } from './product/updateProduct.component';
import { AddFieldComponent } from './product/addField.component';
import { SharedProductFieldComponent } from './shared/sharedProductFields.component';
import { RemoveProductFieldComponent } from './product/removeProductField.component';
import { LoadinViewComponent } from './shared/loadingView.component';
import { ProductDetailComponent } from './product/productDetail.component';
import { ProductReportComponent } from './report/productReport.component';
import { CategoryReportComponent } from './report/categoryReport.component';
import { ShowUserComponent } from './user/showUsers.component';
import { AddOrRemoveRoleInUserComponent } from './shared/addOrRemoveRoleInUser.component';
import { AsignRoleToUserComponent } from './user/asignRoleToUser.component';
import { RemoveRoleFromuserComponent } from './user/removeRoleFromUser.component';
import { UpdateUserComponent } from './user/updateUser.component';



import {UrlBackendProvider} from './urlBackendProvider';
import {ResponseModel} from './response/responseModel';
import {ResponseHandler} from './response/responseHandler';
import {UserContext} from './user/userContext';
import {MainPanelModel} from './mainPanel/mainPanelModel';
import {ReviewModel} from './review/reviewModel';
import { ProductModel } from './product/product.model';
import { ProductService } from './product/product.service';
import { CategoryModel } from './category/category.model';
import { CategoryService } from './category/category.service'
import { CartService } from './cart/cart.service'
import { CartHistoryModel } from './cart/cartHistoryModel'
import { RoleService } from './role/role.service';
import { RoleModel } from './role/role.model';
import { ReportService } from './report/report.service';
import { UserService } from './user/user.service';
import { UserModel } from './user/user.model';
import { LoginService } from './login/login.service';
import { ReviewService } from './review/review.service';

const appRoutes: Routes =([
    {path: 'mainPanel',  component: MainPanelComponent},
    {path: 'login',  component: LoginComponent},
    {path: 'home',  component: AppComponent},
    {path: 'cartView',  component: CartComponent},
    {path: 'pendingReviewView',  component: PendingReviewComponent},
    {path: 'reviewPanel',  component: ReviewComponent},
    {path: 'productReviewPanel',  component: ProductReviewComponent},
    {path: 'viewCartHistory',  component: CartHistoryComponent},
    {path: 'userAccountManager',  component: UserAccountComponent},
    {path: 'addRole' , component:AddRoleComponent},
    {path: 'showRoles' , component:ShowRolesComponent},
    {path: 'updateRole' , component:UpdateRoleComponent},
    {path: 'showUsers' , component:ShowUserComponent},
    {path: 'addCategory' , component:AddCategoryComponent},
    {path: 'showCategories' , component:ShowCategoriesComponent},
    {path: 'updateCategory' , component:UpdateCategoryComponent},
    {path: 'addProductInCategory' , component:AddProductInCategoryComponent},
    {path: 'removeProductFromCategory' , component:RemoveProductFromCategoryComponent},
    {path: 'addUser' , component:AddUserComponent},
    {path: 'addProduct' , component:AddProductComponent},
    {path: 'showProducts' , component:ShowProductsComponent},
    {path: 'updateProduct' , component:UpdateProductComponent},
    {path: 'addFieldOnProduct' , component:AddFieldComponent},
    {path: 'removeFieldFromProduct' , component:RemoveProductFieldComponent,},
    {path: 'showProductDetail' , component:ProductDetailComponent},   
    {path: 'productReport' , component:ProductReportComponent},  
    {path: 'categoryReport' , component: CategoryReportComponent},  
    {path: 'asignRoleToUser' , component: AsignRoleToUserComponent},  
    {path: 'removeRoleFromUser' , component: RemoveRoleFromuserComponent},  
    {path: 'updateUser' , component: UpdateUserComponent}, 

])

@NgModule({
  imports:  [ BrowserModule, 
              HttpModule,
              JsonpModule,
              RouterModule.forRoot(appRoutes) ,
              FormsModule,
              CommonModule],

  declarations: [ AppComponent,
                  MainPanelComponent,
                  LoginComponent,
                  ShowUserComponent,
                  CartComponent,
                  ReviewComponent,
                  PendingReviewComponent,
                  ProductReviewComponent,
                  CartHistoryComponent,
                  UserFormComponent,
                  CartItemComponent,
                  UserAccountComponent,
                  AddRoleComponent,
                  ShowRolesComponent,
                  UpdateRoleComponent,
                  SharedRoleComponent,
                  SharedCategoryComponent,
                  AddOrRemoveProductInCategory,
                  AddCategoryComponent,
                  ShowCategoriesComponent,
                  UpdateCategoryComponent,
                  AddProductInCategoryComponent,
                  RemoveProductFromCategoryComponent,
                  AddUserComponent,
                  AddProductComponent,
                  SharedProductComponent,
                  ShowProductsComponent,
                  UpdateProductComponent,
                  AddFieldComponent,
                  SharedProductFieldComponent,
                  RemoveProductFieldComponent,
                  LoadinViewComponent,
                  ProductDetailComponent,
                  ProductReportComponent,
                  CategoryReportComponent,
                  AsignRoleToUserComponent,
                  AddOrRemoveRoleInUserComponent,
                  RemoveRoleFromuserComponent,
                  UpdateUserComponent],

providers: [  AppComponent,
              UserContext,
              ReviewModel,
              UrlBackendProvider,
              ResponseModel,
              ResponseHandler,
              ProductModel,
              CategoryModel,
              CategoryService,
              CartHistoryModel,
              CartService,
              ProductService,
              RoleModel,
              RoleService,
              ReportService,
              UserService,
              LoginService,
              MainPanelModel,
              UserModel,
              ReviewService],

  bootstrap:    [  AppComponent ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule { 

    
}
