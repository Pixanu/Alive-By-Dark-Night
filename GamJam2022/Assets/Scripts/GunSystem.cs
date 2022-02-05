using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    [Header("Gun properties")]
    public int damage = 50;
    public float interval_between_shooting, spread, reloadTime, interval_between_shots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public float knockbackForce = 30f;

    //bools
    [Header("Gun stats")]
    bool shooting, readyToShoot, reloading;

    //bullet
    [Header("Bullet stats")]
    public GameObject bullet;
    public float shootForce, upwardForce;
    public bool allowInvoke = true;
    GameObject bulletParent;

    //Recoil
    [Header("Recoil")]
    private GameObject mouseLook;
    public float recoilAmountX;
    public float recoilAmountY;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit hit;
    public LayerMask monsterLayer;
    Animator animator;

    //Graphics
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;

        bulletParent = GameObject.FindWithTag("BulletParent");

        //mouseLook = GameObject.Find("Main Camera");
        mouseLook = GameObject.FindObjectOfType<MouseLook>().gameObject;

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckInput();

        text.SetText(bulletsLeft/bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void CheckInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (!shooting)
        {
            mouseLook.GetComponentInParent<MouseLook>().isShaking = false;
        }

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();

            //Recoil
            Recoil();
        }

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            mouseLook.GetComponentInParent<MouseLook>().isShaking = false;
            Reload();
        }

        //Reload automatically when try to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            mouseLook.GetComponentInParent<MouseLook>().isShaking = false;
            Reload();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        muzzleFlash.Play();

        //Find the exact hit position
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits anything
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(200);

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Spread
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(spreadX, spreadY, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;
        currentBullet.transform.parent = bulletParent.transform;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        if(allowInvoke)
        {
            Invoke("ResetShot", interval_between_shooting);
            allowInvoke = false;
        }

        //if more than one bullet per shot
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", interval_between_shots);
    }

    private void Recoil()
    {
        mouseLook.GetComponentInParent<MouseLook>().isShaking = true;
        mouseLook.GetComponentInParent<MouseLook>().GetRecoilValue(recoilAmountX, recoilAmountY);
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        animator.SetBool("reloading", true);
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        animator.SetBool("reloading", false);
    }
}