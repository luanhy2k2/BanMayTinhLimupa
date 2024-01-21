import { Injectable } from '@angular/core';
import { productCart } from 'src/app/Models/productCart.entity';
import { productDetail } from 'src/app/Models/productDetail.entity';

@Injectable({
    providedIn: 'root'
})
export class CartService {

    constructor() { }
    addToCart(item: any) {
        let list!: any[]

        // Set the quantity of the item to 1 by default.
        item.quantity = 1;

        // Get the cart from local storage.
        const cart = localStorage.getItem('cart');

        // If the cart does not exist, create a new list.
        if (cart === null) {
            list = [item];
        } else {
            // Parse the cart from JSON.
            list = JSON.parse(cart);

            // Check if the item is already in the cart.
            let ok = true;
            for (const x of list) {
                if (x.sanpId === item.sanpId) {
                    x.quantity += 1;
                    ok = false;
                    break;
                }
            }

            // If the item is not in the cart, add it.
            if (ok) {
                list.push(item);
            }
        }

        // Save the cart to local storage.
        localStorage.setItem('cart', JSON.stringify(list));

        // Alert the user that the item has been added to the cart.
        alert('Đã thêm giỏ hàng thành công!');
    }
    getTotalPrice() {
        const cartData = this.getCart()
        var cart = JSON.parse(cartData);
        const totalPrice = cart.reduce((acc: any, product: any) => {
            return acc + product.gia * product.quantity;
        }, 0);
        return totalPrice;
    }
    removeItem(id: number) {
        const cartData = this.getCart()
        if (cartData !== null) {
            var cart = JSON.parse(cartData);
            const index = cart.findIndex((product: any) => product.sanpId === id);
            if (index >= 0) {
                cart.splice(index, 1);
            }

            // Lưu trữ giỏ hàng vào localStorage
            localStorage.setItem('cart', JSON.stringify(cart));
        }


    }

    getCart(): any {
        return localStorage.getItem('cart');

    }

}