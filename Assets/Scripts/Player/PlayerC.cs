using UnityEngine;
using UnityEngine.UI;

public class PlayerC : MonoBehaviour
{

    private float cash;
    private bool right = true;
    private bool canMove = true;

    public float speed = 1.5f;
    public bool canSit = false;
    public bool sitting = false;
    public bool onRunningAway = false;

    private AssentoC assento;

    public Button saleButton;
    public Text textCash;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && canMove)
        {
            OnButtonDownMoveRight();
        }               // -> down
        else if (Input.GetKeyUp(KeyCode.RightArrow) && canMove)
        {
            OnButtonUpMoveRight();
        }            // -> up  
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove)
        {
            OnButtonDownMoveLeft();
        }            // <- down   
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && canMove)
        {
            OnButtonUpMoveLeft();
        }             // <- up  
        else if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            OnButtonDownRun();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && canMove)
        {
            OnButtonUpRun();
        }

        if (Input.GetKeyDown(KeyCode.S) && canSit && !sitting)
        {
            canMove = false;
            sitting = true;
            this.SetSitting();
            assento.gameObject.GetComponent<AssentoC>().Sentar(this.gameObject, right);
        }
        else if (Input.GetKeyDown(KeyCode.S) && canSit && sitting)
        {
            canMove = true;
            sitting = false;
            this.SetIdle();
            assento.gameObject.GetComponent<AssentoC>().Levantar(right);

            if (right)
            {
                this.MoveRight();
            }
            else
            {
                this.MoveLeft();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cliente"))
        {
            if (other.GetComponent<ClienteC>().IsWaintgSale())
            {
                var btnSale = saleButton.gameObject.GetComponent<BtnSale>();
                btnSale.Init(other.GetComponent<ClienteC>(), gameObject.GetComponent<PlayerC>());

                saleButton.interactable = true;
            }
        }
        else if (other.CompareTag("assento") && !onRunningAway)
        {
            var tmpAssento = other.GetComponent<GrupoAssentoC>().GetAssento();
            if (tmpAssento == null)
            {
                canSit = false;
                return;
            }
            else
            {
                canSit = true;
                assento = tmpAssento;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cliente"))
        {
            saleButton.interactable = false;
        }
        else if (other.CompareTag("assento"))
        {
            canSit = false;
            assento = null;
        }
    }

    #region Move

    public void OnButtonDownMoveRight()
    {
        if (canMove)
        {
            MoveRight();
            this.SetWalk();
        }

    }

    public void OnButtonUpMoveRight()
    {
        if (canMove)
        {
            this.SetIdle();
        }

    }

    public void OnButtonDownMoveLeft()
    {
        if (canMove)
        {
            MoveLeft();
            this.SetWalk();
        }

    }

    public void OnButtonUpMoveLeft()
    {
        if (canMove)
        {
            this.SetIdle();
        }
    }

    public void OnButtonDownRun()
    {
        if (canMove)
        {
            speed = 2.0f;
            this.SetRun();
        }
    }

    public void OnButtonUpRun()
    {
        if (canMove)
        {
            speed = 1.5f;
            this.SetIdle();
        }
    }

    public void OnButtonDownSit()
    {
        if (canSit && !sitting)
        {
            canMove = false;
            sitting = true;
            this.SetSitting();
            assento.gameObject.GetComponent<AssentoC>().Sentar(this.gameObject, right);
        }
        else if (canSit && sitting)
        {
            canMove = true;
            sitting = false;
            this.SetIdle();
            assento.gameObject.GetComponent<AssentoC>().Levantar(right);

            if (right)
            {
                this.MoveRight();
            }
            else
            {
                this.MoveLeft();
            }
        }
    }

    private void MoveRight()
    {
        if (!right)
        {
            this.gameObject.transform.rotation = Quaternion.Inverse(this.gameObject.transform.rotation);
            right = true;
        }

        this.gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
    }

    private void MoveLeft()
    {
        if (right)
        {
            this.gameObject.transform.rotation = Quaternion.Inverse(this.gameObject.transform.rotation);
            right = false;
        }

        this.gameObject.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
    }

    #endregion

    #region Animations

    private void SetWalk()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walking", true);
        anim.SetBool("sitting", false);
        anim.SetBool("running", false);
    }

    private void SetRun()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walking", false);
        anim.SetBool("sitting", false);
        anim.SetBool("running", true);
    }

    private void SetIdle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
        anim.SetBool("sitting", false);
        anim.SetBool("running", false);
    }

    private void SetSitting()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walking", false);
        anim.SetBool("sitting", true);
        anim.SetBool("running", false);
    }

    #endregion

    public void IncreaseCash(float value)
    {
        cash += value;
        textCash.text = cash.ToString("C");
    }
}
