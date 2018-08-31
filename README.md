# Red Runner

We created this project to give you another example of how you can integrate the _Appcoins_ plugin to your game. For this example we are using an open source game called __Red Runner__. You can check their official page [here](https://github.com/BayatGames/RedRunner).
<p align="center">
  <img src="https://img.itch.zone/aW1hZ2UvMTU4NTg4LzcyNzg3Mi5wbmc=/original/AU5pWY.png" aref = />
</p>

## _AppCoins_ Plugin Integration Example
This is a very simple demonstration of how you can change your game's logic to integrate _AppCoins_ _In-App Purchases_. The only adjustment we made was that after the player dies for the first time if he wants to play another time he has to buy a life.

Process of integration:
1. Download the plugin package corresponding to your Unity version. You can find them on the latest release [here](https://github.com/Aptoide/bds-unity-plugin/releases)
2. At Unity open your game's folder and import the _Appcoins_ unity package you just downloaded. You can do this by clicking in Assets -> Import Package -> Custom Package... .You have to import everything except the '/AppcoinsUnity/Example' folder that is optional. This folder is just another integration example.

4. On GameManager.cs define the product id and create and outlet to Purchaser class

```
public static string kProductIDConsumable = "continue";

[SerializeField]
private Purchaser _purchaser;
```

4. define success and failure functions for the purchase

```
private void OnPurchaseSuccess(AppcoinsProduct product)
{
    Debug.Log("On purchase success called with product: \n skuID: " + product.skuID + " \n type: " + product.productType);

    if (product.skuID == kProductIDConsumable)
    {
        Reset();
        UIManager.Singleton.OpenInGameScreen();   
    }
}

public void OnPurchaseFailed(AppcoinsProduct product)
{
    //If purchase failed show end screen again
    UIManager.Singleton.OpenEndScreen();
}

```

5. Define SetupPurchaser where the purchaser is initialized and the continue product is created.

```
void SetupPurchaser()
{
    Debug.Log("purchaser is " + _purchaser);

    _purchaser.onPurchaseSuccess.AddListener(OnPurchaseSuccess);
    _purchaser.onPurchaseFailed.AddListener(OnPurchaseFailed);

    _purchaser.AddProduct(kProductIDConsumable, AppcoinsProductType.Consumable);

    //Only call initialize after adding all products!    
    Debug.Log("Initializing purchaser");
    _purchaser.InitializePurchasing();
}
```

6. Call SetupPurchaser on Start

```
  void Start () {
    StartCoroutine ( Load () );
    SetupPurchaser();
  }
```

7. Drag the prefab _AppcoinsPurchasing_ to the hierarchy.

8. We set up a label on the top center of the screen and attached it to the purchaser class on the _AppcoinsPurchasing_ object to get the status of the purchasing system.

9. On the hierarchy select Managers and then select Game Manager object. Drag the _AppcoinsPurchasing_ object to the purchaser outlet you just created.

9. Click the _AppcoinsPurchasing_ object and setup the developer address and BDS public key.

```
Developer Wallet Address = 0xa43646ed0ece7595267ed7a2ff6f499f9f10f3c7
```
```
Developer BDS Public key = MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtxkhS3TueyUW/vA2qUBaP+EmIQdXP40ch83cXCTK+sm3cEupJEIpFYgu7Dbdtcm5qKRcoYXA2Rkn4LQsWJ4Ru7RJSE8c7LB995eF/MF5s+L/zkc7eDJP1fWDnte2W4AGYaVaW7lc0+a8hBL29HaljrnJPLNzDC+o3I125MUpl0opQpOaoIgpqdHJDbaJFcC2+ToUlySwVT50eq7/VrtDUowxrbjhJO5J6BV50hOkDnV8eIF8ZXusBjPz25EPgj7dmuE8tcuCYaANawYMkVReWJ1agXwL4ynYDb9bk/0WdF0gPZd0PKaaFE2QtDZltXKokAkbybuC9mSw8iONoIvRiQIDAQAB
```

7. Your game is ready to rock!
