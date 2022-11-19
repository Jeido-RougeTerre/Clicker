using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
    public string name;
    private QState state = QState.NotAvailable;

    private static readonly Dictionary<string, Quest> QUEST = new Dictionary<string, Quest>();

    public Quest(string name) {
        if (Quest.QUEST.ContainsKey(name)) {
            return;
        }

        this.name = name;

        Quest.QUEST.Add(name, this);
    }

    public bool GetQuest(string name, out Quest quest) {
        return QUEST.TryGetValue(name, out quest);
    }

    public bool isComplete() {
        return state == QState.Done;
    }

    public bool isFailled() {
        return state == QState.Fail;
    }

    public bool isDone() {
        return isFailled() || isComplete();
    }

    public QState GetState() {
        return state;
    } 

    public bool ChangeState(QState state) {
        if (this.state == state) {
            return false;
        }

        this.state = state;

        return true;
    }

    public void Complete() {
        state = QState.Done;
        // TODO: event trigger here
    }

    public void Fail() {
        state = QState.Fail;
        // TODO: event trigger here
    }

    public void Start() {
        state = QState.Active;
        // TODO: event trigger here
    }

    public void SetAvailable(bool active = true) {
        if (active) {
            state = QState.Available;
        } else {
            state = QState.NotAvailable;
        }

        // TODO: eventTrigger(bool)
    }
}

public enum QState {
    NotAvailable,
    Available,
    Active,
    Done,
    Fail,
}
