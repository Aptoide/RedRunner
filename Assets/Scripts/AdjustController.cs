using System.Collections;
using System.Collections.Generic;
using com.adjust.sdk;
using UnityEngine;

public class AdjustController : MonoBehaviour
{
    public static string CHOOSE_PAYMENT_EVENT_TOKEN = "3ghvvh";
    public static string PAYMENT_COMPLETED_EVENT_TOKEN = "jx7k6g";
    public static string POPUP_PAYMENT_EVENT_TOKEN = "a1ib4p";

    public static void LogChoosePaymentEvent()
    {
        LogAdjustEvent(CHOOSE_PAYMENT_EVENT_TOKEN);
    }

    public static void LogPaymentCompletedEvent(string val)
    {
        LogAdjustRevenueEvent(PAYMENT_COMPLETED_EVENT_TOKEN,val);
    }

    public static void LogPopupPaymentEvent()
    {
        LogAdjustEvent(POPUP_PAYMENT_EVENT_TOKEN);
    }

    static void LogAdjustEvent(string eventToken)
    {
        AdjustEvent adjustEvent = new AdjustEvent(eventToken);
        Adjust.trackEvent(adjustEvent);
    }

    static void LogAdjustRevenueEvent(string eventToken, string strValue) {
        AdjustEvent adjustEvent = new AdjustEvent(eventToken);

        double value = 0.0;

        double.TryParse(strValue, out value);

        adjustEvent.setRevenue(value, "EUR"); //TODO how to create custom currency?
        //adjustEvent.setTransactionId("transactionId");

        Adjust.trackEvent(adjustEvent);
    }
}
