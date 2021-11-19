# pe

Promotion Engine

Thoughts:

Look to abstract implementations further so that classes are not dependant on concrete implementations, e.g. Cart class could accept an IPromotionStore and so accept different implementations or mocks (when unit testing).
Maybe see if the promotion that was applied needs to be stored against the applicable products in the cart.
Depending on how products are represented in the cart, refactoring might be needed if say products are just SKU and quantity when multiples rather than individual objects.
Additional promotion types should be easily added as long as they implement the IPromotion interface.