class OrderConfirmationPage {

    checkConfirmationMessage() {
        return cy.get('h2.complete-header')
    }
}

export default OrderConfirmationPage