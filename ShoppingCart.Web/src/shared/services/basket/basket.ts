import {Money} from '../../common/money';
import {Pizza} from '../pizza/pizza';

export class Basket {
    constructor() {
        this.items = [];
        this.adjustedPrice = false;
        this.total = {
            inFull: '£0.00',
            inPence: 0,
            inPounds: 0
        };
    }

    adjustedPrice: boolean;
    total: Money;
    items: Pizza[];
}
